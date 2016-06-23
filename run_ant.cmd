
@echo off
set CURDIR=%CD%

: Check to see if JAVA_HOME is set properly
cd %JAVA_HOME%
if not exist .\bin\javac.exe goto NO_JAVA_HOME

: Check for the Ant installation.  First use whatever the user has defined, then try setting to our default location.
cd %ANT_HOME%
if exist .\bin\ant.bat goto BUILD
set ANT_HOME=C:\toolbox\apache-ant-1.7.1
if not exist %ANT_HOME%\bin\ant.bat goto NO_ANT_INSTALLED

:BUILD
cd %CURDIR%

set PATH=%JAVA_HOME%\bin;%ANT_HOME%\bin;

: you can pass parameters to ANT by specifying "-D<param=value>" on the command line
ant -buildfile %BuildFile% -Dversion.number=1.0.0 %*

goto EOF

: Subroutines
:NO_JAVA_HOME
echo ** You must define JAVA_HOME before running this script.  In your environment settings you may set JAVA_HOME to the directory of your JDK installation.
goto EOF

:NO_ANT_INSTALLED

echo ** You must install ANT or define ANT_HOME before proceeding.  In your environment settings you may set ANT_HOME to the directory of your ANT installation.
goto EOF

:EOF
cd %CURDIR%