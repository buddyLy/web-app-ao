set RunDirectory=%0
set RunDirectory=%RunDirectory:\build.cmd=%
set RunDirectory=%RunDirectory:build.cmd=%
echo Run Location = %RunDirectory%
set BuildFile=build%1.xml
echo using %BuildFile%
cd %RunDirectory%

run_ant.cmd -Dpublish.type=dev package