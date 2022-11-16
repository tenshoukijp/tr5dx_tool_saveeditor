@echo off
setlocal ENABLEDELAYEDEXPANSION

cd /d %~dp0

If not exist Image\ mkdir Image
If not exist Image\FamilyCrest\ mkdir Image\FamilyCrest
If not exist Image\Item\ mkdir Image\Item
If not exist Image\Kyoten\ mkdir Image\Kyoten

If exist MAIN\ (
    copy /Y MAIN\003.dds Image\FamilyCrest\FamilyCrest.dds
)

If exist ITEM\ (
    For /l %%i in (0, 1, 103) do (
        set num=000%%i
        set num=!num:~-3!
        copy /Y ITEM\!num!.dds Image\Item\%%i.dds
    )
)

If exist TOWN\ (
    For /l %%i in (0, 1, 38) do (
        copy /Y TOWN\%%i\000.dds Image\Kyoten\%%i.dds
    )
)
