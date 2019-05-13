$version_api = "https://nuosoon.com/NugetApi/GetVersion?id=";
$output_path = "D:\nuget\local";
$sln_path = "E:\Code-Product\Vli\Vli.sln";

# 预打包
echo "预打包"

dotnet pack -o="$output_path" $sln_path -c Release

# 获取所有包
$packages = Get-ChildItem -Path "$output_path" -Filter *.nupkg -Recurse;
$package_ids = New-Object -TypeName System.Collections.ArrayList;
$package_versions = New-Object -TypeName System.Collections.ArrayList;
$package_names = New-Object -TypeName System.Collections.ArrayList;

# 获取Nuget打包后的ID  
foreach($pk in $packages)
{
    $name = $pk.Name.Split(".");   
    $id = "";
    for($i=0;$i -le $name.Length-5;$i++ )
    {
        $id += $name[$i]+".";
    }
    $id = $id.TrimEnd('.');
    if(!$package_ids.Contains($id))
    {
         $package_ids.Add($id);    
    }   
};

# 获取版本
foreach($pack in $package_ids)
{
    $url = $version_api + $pack;
    $version_json = Invoke-WebRequest -Uri $url -UseBasicParsing;
    $version = ($version_json.Content | ConvertFrom-Json).NextVersion;
    $package_versions.Add($version);    
};

$package_versions.Sort();
$max_version = $package_versions[$package_versions.Count-1];

# 设置包名
foreach($packn in $package_ids)
{
    $package_name = $packn + "." + $max_version + ".nupkg";
    $package_names.Add($package_name);
}

if($max_version -eq $null)
{
    echo "第一次生成";
    
    # 打包
    dotnet pack $sln_path -o="$output_path" -c Release /p:PackageVersion=1.0.0;   
} 
else
{
    echo "删除旧包..."
    Remove-Item "$output_path\*" -include *.nupkg
    dotnet pack $sln_path -o="$output_path" -c Release /p:PackageVersion=$max_version ;
}

$packages_up = Get-ChildItem -Path "$output_path" -Filter *.nupkg -Recurse;
foreach($p in $packages_up)
{
    $pname = $p.Name;
    # 上传包
    nuget push "$output_path\$pname" F5141BA8-AC71-4342-9C1D-39A97B3B8B2E -src https://nuget.nuosoon.com/nuget ;
}

echo "打包上传完成";