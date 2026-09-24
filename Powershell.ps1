# PowerShell script to search and replace text inside files and rename files/folders in a folder and subfolders

#$folderPath = "C:\Gems Source SQL\DBSQL\UTMUSER"  # Your folder path
$folderPath = "C:\Gems Source SQL\TA SOURCE\TA540"  # Your folder path
#$folderPath = "C:\Gems Source SQL\Fixes\Fix_TA432"  # Your folder path
$searchText = "TA440"
$replaceText = "TA540"

# Step 1: Rename folders that contain the search text, starting from the deepest folders first
Get-ChildItem -Path $folderPath -Recurse -Directory | Sort-Object FullName -Descending | ForEach-Object {
    $folderName = $_.Name
    $folderFullPath = $_.FullName

    if ($folderName -like "*$searchText*") {
        $newFolderName = $folderName -replace $searchText, $replaceText
        $newFolderPath = Join-Path -Path $_.Parent.FullName -ChildPath $newFolderName

        # Rename the folder
        Rename-Item -Path $folderFullPath -NewName $newFolderPath
        Write-Host "Renamed folder: $folderFullPath to $newFolderPath"
    }
}

# Step 2: Search and replace text inside all files and rename files
Get-ChildItem -Path $folderPath -Recurse | ForEach-Object {
    $filePath = $_.FullName

    # Skip directories since they've been renamed already
    if (-not $_.PSIsContainer) {
        # Read the content of the file
        $content = Get-Content -Path $filePath -Raw -ErrorAction SilentlyContinue

        # Replace the search text with the replace text in the file content
        if ($content -like "*$searchText*") {
            $newContent = $content -replace $searchText, $replaceText

            # Write the new content back to the file if a replacement was made
            Set-Content -Path $filePath -Value $newContent
            Write-Host "Updated content in: $filePath"
        }

        # Rename the file if its name contains the search text
        $fileName = $_.Name
        if ($fileName -like "*$searchText*") {
            $newFileName = $fileName -replace $searchText, $replaceText
            $newFilePath = Join-Path -Path $_.DirectoryName -ChildPath $newFileName

            # Rename the file
            Rename-Item -Path $filePath -NewName $newFilePath
            Write-Host "Renamed file: $filePath to $newFilePath"
        }
    }
}