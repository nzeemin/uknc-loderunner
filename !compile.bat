@echo off

for /f "tokens=2 delims==" %%a in ('wmic OS Get localdatetime /value') do set "dt=%%a"
set "YY=%dt:~2,2%" & set "YYYY=%dt:~0,4%" & set "MM=%dt:~4,2%" & set "DD=%dt:~6,2%"
set "DATESTAMP=%YYYY%-%MM%-%DD%"
for /f %%i in ('git rev-list HEAD --count') do (set REVISION=%%i)
echo REV.%REVISION% %DATESTAMP%

echo VERSTR:	.ASCIZ /REV.%REVISION% %DATESTAMP%/ > VERSIO.MAC
echo	.EVEN >> VERSIO.MAC

@echo on
@if exist LEVELS.OBJ del LEVELS.OBJ
@if exist MAIN.LST del MAIN.LST
@if exist MAIN.OBJ del MAIN.OBJ
C:\bin\rt11\rt11.exe MACRO LEVELS.MAC
C:\bin\rt11\rt11.exe MACRO/LIST:DK: MAIN.MAC+SYSMAC.SML/LIBRARY
