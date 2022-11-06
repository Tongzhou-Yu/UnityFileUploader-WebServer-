## Uploader.cs
C# Script is using unity's UnityWebRequest to upload a file to HTTP web server.  
Change 10th line as where you upload the WebUploader folder: string url = "https://xxxxxxxxx/UnityUpload.php"  
## WebUpload Folder
Upload to your web server to receive file.
Change UnityUpload.php's 41th line $myFile = $file_path.$_REQUEST['Name'].".Format Of Your File";
