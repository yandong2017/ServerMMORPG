color 2f

set sc1=F:\SangoGai\Server\APublish\Config
set des1=F:\SangoGai\Server\APublish\数据查询工具\Config
xcopy %sc1%\Xml\*.* %des1%\Xml\ /y

set sc=F:\SangoGai\Server\APublish\
set des=F:\SangoGai\Public\
xcopy %sc%表格工具\*.* %des%表格工具\ /y
xcopy %sc%管理工具\*.* %des%管理工具\ /y
xcopy %sc%数据查询工具\*.* %des%数据查询工具\ /y
xcopy %sc%数据查询工具\Config\Xml\*.* %des%数据查询工具\Config\Xml\ /y
xcopy %sc%记录查询工具\*.* %des%记录查询工具\ /y

pause