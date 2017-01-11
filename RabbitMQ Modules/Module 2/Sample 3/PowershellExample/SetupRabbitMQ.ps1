param([String]$RabbitDllPath = "not specified")
Set-ExecutionPolicy Unrestricted
Write-Host "Rabbit DLL Path: "
Write-Host $RabbitDllPath -ForegroundColor green

$absoluteRabbitDllPath = Resolve-Path $RabbitDllPath

Write-Host "Absolute Rabbit DLL Path"
Write-Host $absoluteRabbitDllPath -ForegroundColor green

[Reflection.Assembly]::LoadFile($absoluteRabbitDllPath)

Write-Host "Setting up Rabbit MQ Connection Factory"
$factory = New-Object RabbitMQ.Client.ConnectionFactory

$hostNameProp = [RabbitMQ.Client.ConnectionFactory].GetField("HostName")
$hostNameProp.SetValue($factory, "localhost")

$userNameProp = [RabbitMQ.Client.ConnectionFactory].GetField("UserName")
$userNameProp.SetValue($factory, "guest")

$password = [RabbitMQ.Client.ConnectionFactory].GetField("Password")
$password.SetValue($factory, "guest")

$createConnectionMethod = [RabbitMQ.Client.ConnectionFactory].GetMethod("CreateConnection", [Type]::EmptyTypes)

$connection = $createConnectionMethod.Invoke($factory, "instance,public", $null, $null, $null)

Write-Host "Setting Up RabbitMQ Model"
$model = $connection.CreateModel()

Write-Host "Creating Queue"
$model.QueueDeclare("Module2.Sample2", $true, $false, $false, $null)

Write-Host "Setup Complete"


