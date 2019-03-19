if ($args)
{
    $command = 'dotnet run -c Release -f netcoreapp2.1 -- ' + $args[0] 

    iex $command
}
else
{
    Write-Host "Output folder name needed as argument"
}