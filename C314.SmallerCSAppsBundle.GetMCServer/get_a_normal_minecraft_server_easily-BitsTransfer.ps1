$version = Read-Host -Prompt 'input the minecraft version you want your server to be(Ex. 1.16.3, 1.12.2, 1.13 Etc.(Supports from 1.12.2 and up))'
$output = Read-Host -Prompt 'input destinationfolder(every folder has to exist already)'
$start_time = Get-Date

switch($version)
{
    '1.12.2'{$url = 'https://launcher.mojang.com/v1/objects/886945bfb2b978778c3a0288fd7fab09d315b25f/server.jar'}
    '1.13'{$url = 'https://launcher.mojang.com/v1/objects/d0caafb8438ebd206f99930cfaecfa6c9a13dca0/server.jar'}
    '1.13.1'{$url = 'https://launcher.mojang.com/v1/objects/fe123682e9cb30031eae351764f653500b7396c9/server.jar'}
    '1.13.2'{$url = 'https://launcher.mojang.com/v1/objects/3737db93722a9e39eeada7c27e7aca28b144ffa7/server.jar'}
    '1.14'{$url = 'https://launcher.mojang.com/v1/objects/f1a0073671057f01aa843443fef34330281333ce/server.jar'}
    '1.14.1'{$url = 'https://launcher.mojang.com/v1/objects/ed76d597a44c5266be2a7fcd77a8270f1f0bc118/server.jar'}
    '1.14.2'{$url = 'https://launcher.mojang.com/v1/objects/808be3869e2ca6b62378f9f4b33c946621620019/server.jar'}
    '1.14.3'{$url = 'https://launcher.mojang.com/v1/objects/d0d0fe2b1dc6ab4c65554cb734270872b72dadd6/server.jar'}
    '1.14.4'{$url = 'https://launcher.mojang.com/v1/objects/3dc3d84a581f14691199cf6831b71ed1296a9fdf/server.jar'}
    '1.15'{$url = 'https://launcher.mojang.com/v1/objects/e9f105b3c5c7e85c7b445249a93362a22f62442d/server.jar'}
    '1.15.1'{$url = 'https://launcher.mojang.com/v1/objects/4d1826eebac84847c71a77f9349cc22afd0cf0a1/server.jar'}
    '1.15.2'{$url = 'https://launcher.mojang.com/v1/objects/bb2b6b1aefcd70dfd1892149ac3a215f6c636b07/server.jar'}
    '1.16'{$url = 'https://launcher.mojang.com/v1/objects/a0d03225615ba897619220e256a266cb33a44b6b/server.jar'}
    '1.16.1'{$url = 'https://launcher.mojang.com/v1/objects/a412fd69db1f81db3f511c1463fd304675244077/server.jar'}
    '1.16.2'{$url = 'https://launcher.mojang.com/v1/objects/c5f6fb23c3876461d46ec380421e42b289789530/server.jar'}
    '1.16.3'{$url = 'https://launcher.mojang.com/v1/objects/f02f4473dbf152c23d7d484952121db0b36698cb/server.jar'}
    '1.16.4'{$url = 'https://launcher.mojang.com/v1/objects/35139deedbd5182953cf1caa23835da59ca3d7cd/server.jar'}
    '1.16.5'{$url = 'https://launcher.mojang.com/v1/objects/1b557e7b033b583cd9f66746b7a9ab1ec1673ced/server.jar'}
    '1.17'{$url = 'https://launcher.mojang.com/v1/objects/0a269b5f2c5b93b1712d0f5dc43b6182b9ab254e/server.jar'}
    '1.17.1'{$url = 'https://launcher.mojang.com/v1/objects/a16d67e5807f57fc4e550299cf20226194497dc2/server.jar'}
    '1.18'{$url = 'https://launcher.mojang.com/v1/objects/3cf24a8694aca6267883b17d934efacc5e44440d/server.jar'}
    '1.18.1'{$url = 'https://launcher.mojang.com/v1/objects/125e5adf40c659fd3bce3e66e67a16bb49ecc1b9/server.jar'}
    default{Write-Output "You need to input a valid version, please restart the script to do so"}
}

Import-Module BitsTransfer
Start-BitsTransfer -Source $url -Destination $output

Write-Output "Time taken: $((Get-Date).Subtract($start_time).Seconds) second(s)"

Set-Location $output
java -Xmx1024M -Xms1024M -jar server.jar nogui | Out-Null
$file = $output + '\eula.txt'
((Get-Content -path $file -Raw) -replace 'false','true') | Set-Content -Path $file
$file2 = $output + '\Start.cmd'
New-Item -Path $file2 -ItemType File
Set-Content -Path $file2 -Value 'java -Xmx1024M -Xms1024M -jar server.jar nogui'
$file3 = $output + '\README.txt'
New-Item -Path $file3 -ItemType File
Set-Content -Path $file3 -Value 'Thanks For Using This Script. When You Want To Stop The Minecraft Server Type stop in the console.'
Write-Output "Thanks For Using This Script. When You Want To Stop The Minecraft Server Type stop in the console."
java -Xmx1024M -Xms1024M -jar server.jar nogui
