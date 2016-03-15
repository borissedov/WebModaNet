:: Script da eseguire negli eventi post build per la compressione dei file JavaScript e CSS

:: Combina i file CSS in un unico file site.debug.css
"$(ProjectDir)tools\Packer.exe" -o "$(ProjectDir)Styles\site.debug.css" -m combine "$(ProjectDir)Styles\Site.css" "$(ProjectDir)Styles\menu.css" "$(ProjectDir)Styles\nyroModal.css" "$(ProjectDir)Styles\jquery-ui-1.8.12.custom.css"

:: Effettua la compressione dei file CSS in un unico file site.min.css
"$(ProjectDir)tools\Packer.exe" -o "$(ProjectDir)Styles\site.min.css" -m cssmin "$(ProjectDir)Styles\site.debug.css"

:: Combina i file JavaScript in un unico file site.debug.js
"$(ProjectDir)tools\Packer.exe" -o "$(ProjectDir)Scripts\site.debug.js" -m combine "$(ProjectDir)Scripts\jquery-1.5.1.min.js" "$(ProjectDir)Scripts\jquery.cookie.js" "$(ProjectDir)Scripts\jquery-ui-1.8.12.custom.min.js" "$(ProjectDir)Scripts\jquery.ui.datepicker-it.js" "$(ProjectDir)Scripts\jquery.nyroModal.custom.min.js" "$(ProjectDir)Scripts\jquery.fixedtableheader-1-0-2.min.js" "$(ProjectDir)Scripts\webmoda.js"

:: Effettua la compressione dei file JavaScript in un unico file site.min.js
"$(ProjectDir)tools\Packer.exe" -o "$(ProjectDir)Scripts\site.min.js" -m jsmin "$(ProjectDir)Scripts\site.debug.js"

:: Compressione tramite jsmin (obsoleto)
:: TYPE "$(ProjectDir)Scripts\jquery-1.5.1.min.js" "$(ProjectDir)Scripts\jquery.cookie.js" "$(ProjectDir)Scripts\jquery-ui-1.8.12.custom.min.js" "$(ProjectDir)Scripts\jquery.ui.datepicker-it.js" "$(ProjectDir)Scripts\jquery.nyroModal.custom.min.js" "$(ProjectDir)Scripts\jquery.fixedtableheader-1-0-2.min.js" "$(ProjectDir)Scripts\webmoda.js" | "$(ProjectDir)tools\jsmin.exe" > "$(ProjectDir)Scripts\site.min.js"
