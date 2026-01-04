param([string] $packagesVersions)

$templateNuspecPath = "template-publish/TechAdvisor.IdentityServer8.Admin.Templates.nuspec"
nuget pack $templateNuspecPath -NoDefaultExcludes

dotnet.exe new --uninstall TechAdvisor.IdentityServer8.Admin.Templates

$templateLocalName = "TechAdvisor.IdentityServer8.Admin.Templates.$packagesVersions.nupkg"
dotnet.exe new -i $templateLocalName

dotnet.exe new techadvisor.is8admin --name MyProject --title MyProject --adminemail 'admin@template.com' --adminpassword 'Pa$$word123' --adminrole MyRole --adminclientid MyClientId --adminclientsecret MyClientSecret --dockersupport true