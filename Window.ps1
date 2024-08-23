[System.Reflection.Assembly]::LoadWithPartialName("PresentationFramework") | Out-Null

function Import-Xaml {
    [xml]$xaml = Get-Content -Path $PSScriptRoot\window.xaml
    $manager = New-Object System.Xml.XmlNamespaceManager - ArgumentList $xaml.NameTable
    $manager.AddNamespace("x", "http://schemas.microsoft.com/winfx/2006/xaml");
    $xamlReader = New-Object System.Xml.XmlNodeReader $xaml
    [Window.Markup.XamlReader]::Load($xamlReader)
}

$Window = Import-Xaml
$Window.ShowDialog()