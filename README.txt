To Use:
Create new PlayerClassSO or EnemyClassSO, drag and drop stat CSV file into field and press PopulateFromCSV button.
You can then batch modify the stats from the editor for tuning using the field StatModifiers.

The CSVReader is dependent on the Stat Spreadsheet layout, and the string names of classes and stats.
Each SO uses object's name as the Class Key unless the Class Key Override is specified. To populate the data from the correct class section in the spreadsheet, enter the correct string in Class Key Override, or use the string as the object's name. The Class Key Override is prioritised over the object name.
E.g. Player SO doesn't need override to find player stats in spreadsheet. Gobble Goop SO uses override string "Player" to populate from the player stats in the spreadsheet.
***IMAGES***

To help reduce string reference issues the ClassStatConsts class hold const string references which are used via variable name.
Add New Stats/Classes:
