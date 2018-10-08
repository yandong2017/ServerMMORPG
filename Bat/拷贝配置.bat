color 2f

set sc=..\..\Public\Config
set des=..\..\Server\APublish\Config
set des2=..\..\Server\ServerBase\Config
del /q/a/f %des%\Xml\*.*
xcopy %sc%\Xml\*.* %des%\Xml\ /y
copy %sc%\Class\ClassServer.cs %des2%\ClassServer.cs /y
copy %sc%\Class\ClassServerConf.cs %des2%\ClassServerConf.cs /y
copy %sc%\Class\ClassServerConfRead.cs %des2%\ClassServerConfRead.cs /y

pause