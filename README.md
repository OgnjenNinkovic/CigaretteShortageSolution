# Cigarette deficiency control application

I developed this application to try to reduce the constant problem of cigarette deficiency. The application archives each control count of cigarettes and performs precisely comparison off control count by date.

## Instructions
### The application uses a .xls Excel file as the database, copied to C:\Users\currentUser\Documents\PopisCigara directory.
### when a deficiency or surplus is found during the check count, use the barcode reader to read the barcode of the item and enter the deficiency or surplus number.
![LinkedIn Learning](MainWin.jpg)



### After finishing the cigarette count by clicking on the "IZVEŠTAJ" button, we can print the current status.
![LinkedIn Learning](Izvestaj.GIF)

### If we want to pay the current deficit, by clicking on the "barcode report" button, we only get barcodes. Using the barcode reader we just go over the barcodes and the status of the list is recorded at the cash register. 
![LinkedIn Learning](BarkodIzvestaj.GIF)




### Clicking on the "ARHIVIRAJ" button saves the current counting status in the csv file in the C:\Users\current user\Documents\PopisCigara\Popisi Directory.
![LinkedIn Learning](Arhiviraj.jpg)



### Clicking on the "ANALIZA POPISA" button opens a window with an overview of all archived check counts. 
![LinkedIn Learning](Analiza.jpg)



### This window shows all archived check counts, grouped by date, also shows the amount in cash as well as the total number of disputed items. 
![LinkedIn Learning](Analiza1.jpg)



### When a date is selected, the application scans all check counts and compares them with the date selected and records the differences. items that are not on the selected counting date are marked in red. Purple items are marked on the selected check count, but also on all remaining check counts and they difference in the number of items.
![LinkedIn Learning](Analiza2.jpg)

## Installing

1. simply run the installshield wizard and follow the instructions.