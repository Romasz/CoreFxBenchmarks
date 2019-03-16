if ($args)
{
    $command = 'dotnet run -c Release -f netcoreapp2.1 -- -f *'
    $command += ' --coreRun "C:\Current\GithubProjects\corefx\artifacts\bin\testhost\netcoreapp-Windows_NT-Release-x64\shared\Microsoft.NETCore.App\9.9.9\CoreRun.exe"'
    $command += ' --artifacts ".\' + $args[0] + '"'

    iex $command
}
else
{
    Write-Host "Output folder name needed as argument"
}