@cls
@if exist LEVELS.OBJ del LEVELS.OBJ
C:\bin\rt11\rt11.exe MACRO LEVELS.MAC
@if exist MAIN.LST del MAIN.LST
@if exist MAIN.OBJ del MAIN.OBJ
C:\bin\rt11\rt11.exe MACRO/LIST:DK: MAIN.MAC+SYSMAC.SML/LIBRARY
