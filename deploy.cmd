set RunDirectory=%0
set RunDirectory=%RunDirectory:\deploy.cmd=%
set RunDirectory=%RunDirectory:deploy.cmd=%
echo Run Location = %RunDirectory%
set BuildFile=build.xml
echo using %BuildFile%
cd %RunDirectory%

run_ant.cmd -Dpublish.type=deploy