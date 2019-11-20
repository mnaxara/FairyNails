#concat power shell script

$folders = Get-ChildItem ".\" | Where-Object {$_.Attributes -eq 'Directory'}

#suppression du fichier all
ForEach ($folder in $folders) {
    if (Test-Path all.sql) {
        Remove-Item all.sql
    }
}

# créatoin du fichier sql par répertoire + allscripts
for ($i = 0; $i -lt $folders.Count; $i++) {
    $outfile = $folders[$i].FullName + ".sql"
    Write-Output $outfile;
    #suppression du fichier s'il existe
    if (Test-Path $outfile) {
        Remove-Item $outfile
    }
	
    #concaténation + allscripts.sql
    $files = Get-ChildItem $folders[$i] -Filter *.sql  -Recurse | ForEach-Object { $_.FullName }

    Get-Content $files | Set-Content $outfile

    Get-Content $files | Add-Content all.sql
}
