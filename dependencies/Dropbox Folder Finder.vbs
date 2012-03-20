'
' Find the Dropbox Folder Location
'
' Updated to write path to registry key HKEY_CURRENT_USER\Software\Dropbox\DropboxPath
' Updated to write path to Environment variable %DropboxPath%
'
Option Explicit


Dim WshShell, fso, sDropboxPath
 
Set WshShell = CreateObject("Wscript.Shell")
Set fso      = CreateObject("Scripting.FileSystemObject")

sDropboxPath = vbNullString
sDropboxPath = GetDropboxRoot()

If Len(sDropboxPath) > 0 Then
	WScript.Echo "Your Dropbox folder is located at " & sDropboxPath

	' update the registry and environment variable so other apps can find the path.
	WritePathToRegistry sDropboxPath

Else 
	WScript.Echo "Looks like Dropbox is not installed on this computer." &  VbCrLf & "Please install Dropbox and run this script again." 
End If

WScript.Sleep(2000)  ' sleep for 2 seconds just for fun as an example.
WScript.Quit()

Sub WritePathToRegistry( sDropboxPath )
' dropbox only writes the ...\Application Data\Dropbox\bin path to the registry
' as HKEY_CURRENT_USER\Software\Dropbox\InstallPath
' Write our path to HKEY_CURRENT_USER\Software\Dropbox\DropboxPath
' so any script can easily find it since its not likely to change.
' also set %DropboxPath% environment variable so BAT scripts can use it too.
'
On Error Resume Next

Dim sTemp

	sTemp = vbNullString
	sTemp = WSHShell.RegRead("HKCU\Software\Dropbox\DropboxPath")

	if sTemp <> sDropboxPath Then
		WSHShell.RegWrite "HKCU\Software\Dropbox\DropboxPath", sDropboxPath
	End If

	sTemp = vbNullString
	sTemp = WSHShell.Environment.item("DropboxPath")

	if sTemp <> sDropboxPath Then
		' set a permanent environment variable %DropboxPath% for all users
		WSHShell.Environment.item("DropboxPath") = sDropboxPath
	
		' if the above setting isn't permanent, try this one.
		' this Will set a permanent environment variable for all users.
		'	With WSHShell.Environment("SYSTEM")
		'		.item("DropboxPath") = sDropboxPath
		'	End With
		'
	End If

End Sub


Function GetDropboxRoot()
' find the path for Dropbox's root watch folder from its sqlite host.db database.
' Dropbox stores its databases under the currently logged in user's %APPDATA% path.
' If you have installed multiple instances of dropbox under the same login this only finds the 1st one.
'
	Dim sConfigFile, sLine

	GetDropboxRoot = vbNullString
	sConfigFile    = vbNullString
	sLine          = vbNullString

	' Dropbox stores its databases under the currently logged in user's %APPDATA% path.
	' usually "C:\Documents and Settings\<login_account>\Application Data"

	sConfigFile = WshShell.ExpandEnvironmentStrings("%APPDATA%")
	sConfigFile = sConfigFile & "\Dropbox\host.db"

	' return null string if can't find or work database file.
	If Not fso.FileExists( sConfigFile ) Then Exit Function

	' Dropbox Watch Folder Location is base64 encoded as the last line of the host.db file.
	With fso.OpenTextFile( sConfigFile, 1)
		Do Until .AtEndOfStream
			sLine = .ReadLine 
		Loop
		.Close
	End With 

	' decode last line from base64, path to dropbox watch folder, no trailing slash.
	GetDropboxRoot = Base64Decode(sLine)

End function

' Decodes a base-64 encoded string (BSTR type).
' 1999 - 2004 Antonin Foller, http://www.motobit.com
Function Base64Decode(ByVal base64String)
  Const Base64 = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/"
  Dim dataLength, sOut, groupBegin
  
  base64String = Replace(base64String, vbCrLf, "")
  base64String = Replace(base64String, vbTab, "")
  base64String = Replace(base64String, " ", "")
  
  dataLength = Len(base64String)
  If dataLength Mod 4 <> 0 Then
    Err.Raise 1, "Base64Decode", "Bad Base64 string."
    Exit Function
  End If
 
  
  For groupBegin = 1 To dataLength Step 4
    Dim numDataBytes, CharCounter, thisChar, thisData, nGroup, pOut
    numDataBytes = 3
    nGroup = 0
 
    For CharCounter = 0 To 3
      thisChar = Mid(base64String, groupBegin + CharCounter, 1)
 
      If thisChar = "=" Then
        numDataBytes = numDataBytes - 1
        thisData = 0
      Else
        thisData = InStr(1, Base64, thisChar, vbBinaryCompare) - 1
      End If
      If thisData = -1 Then
        Err.Raise 2, "Base64Decode", "Bad character In Base64 string."
        Exit Function
      End If
 
      nGroup = 64 * nGroup + thisData
    Next
    
    nGroup = Hex(nGroup)
    nGroup = String(6 - Len(nGroup), "0") & nGroup
    
    pOut = Chr(CByte("&H" & Mid(nGroup, 1, 2))) + _
      Chr(CByte("&H" & Mid(nGroup, 3, 2))) + _
      Chr(CByte("&H" & Mid(nGroup, 5, 2)))
    
    sOut = sOut & Left(pOut, numDataBytes)
  Next
 
  Base64Decode = sOut
End Function
