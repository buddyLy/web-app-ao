
set RunDirectory=%0
set RunDirectory=%RunDirectory:\pull_libs.cmd=%
set RunDirectory=%RunDirectory:pull_libs.cmd=%
echo Run Location = %RunDirectory%
set BuildFile=build%1.xml
echo using %BuildFile%
cd %RunDirectory%

run_ant.cmd -Dpublish.type=dev restore
