To Use:
Create new PlayerClassSO or EnemyClassSO, drag and drop stat CSV file into field and press PopulateFromCSV button.
You can then batch modify the stats from the editor for tuning using the field StatModifiers.

The CSVReader is dependent on the file layout, and the string names of classes and keys.
Each SO uses object's name as the Class Key unless the Class Key Override is specified. To populate the data from the correct class section in the spreadsheet, enter the correct string in Class Key Override, or use the string as the object's name. The Class Key Override is prioritised over the object name.
