## Quick Use Information:

Create new PlayerClassSO or EnemyClassSO, drag and drop stat CSV file into field and press PopulateFromCSV button. You can then batch modify the stats from the editor for tuning using the field StatModifiers.

The CSV Reader uses layout rules to sort the stat spreadsheet into a nested dictionary   
(\<Class Name, \<Stat Name, Stat Values\>\>). The SO class code is where you access the dictionary to populate the class’s stats, and must be updated for added stats.

## Editing and Reading the Stat Spreadsheet:

Edit/Add to the Stat Spreadsheet in editing software eg Excel, LibreOffice Calc (free). The CSV Reader is dependent on the Stat Spreadsheet layout, and the string names of classes and stats:

- String identifiers must be the exact strings referenced in code, including any whitespaces and without any extra whitespace at the end

  - Each row where you want a stat identified must have the class cell filled in with the exact class string

  - Each stat must be named with the exact stat string

- The level columns have to start at the 3rd column

- Any columns after levels can be used for calculations etc, these will be ignored provided the column header is not an int
<img width="1852" height="633" alt="Spreadsheet" src="https://github.com/user-attachments/assets/79944bfb-f129-41b3-b0c2-6a6edb5938c3" />

Export this spreadsheet as a .csv file and import into Unity.

The CSV Reader is a static class that sorts this data into a dictionary of classes each of which contains a dictionary of stats.

The class scriptable objects run methods when the custom editor buttons are clicked. CSVPopulableSOEditor.cs uses Unity’s editor API to create these buttons.

Each SO uses it’s name as the Class Key unless the Class Key Override is specified. To populate the data from the correct class section in the spreadsheet, enter the correct string in Class Key Override, or use the string as the object's name. The Class Key Override is prioritised over the object name. E.g. Player SO doesn't need override to find player stats in spreadsheet. GobbledyGoop SO uses override string "Player" to populate from the player stats in the spreadsheet. 

<img width="936" height="762" alt="2026-11-03 19_21_57-README odt — LibreOffice Writer" src="https://github.com/user-attachments/assets/0409e1cb-63be-4892-b9fe-b3fe220cf982" />

To help reduce string reference issues the ClassStatConsts class holds const string references which are used via variable name.

<img width="460" height="106" alt="Const Explanation" src="https://github.com/user-attachments/assets/49d4fafb-be62-412d-9bba-ca41b36c108f" />

<img width="719" height="511" alt="ClassStatConsts" src="https://github.com/user-attachments/assets/a762763a-17a5-4b58-aa6e-41373aeb497c" />



## How to add your own classes or stats:

Follow the spreadsheet layout rules to add classes and stats and then export spreadsheet as .csv file and import csv file into Unity.

To populate a new class create a new  PlayerClassSO or EnemyClassSO and use the exact class string from the csv as either the SO name or as the Class Key Override.

To populate new stats: If the stat/s you added are shared between player and enemy classes, add the following to CharacterClassSO.cs, otherwise add to either PlayerClassSO.cs or EnemyClassSO.cs:

Add to the top of the class the following to create stat array and modifier fields:
<img width="451" height="106" alt="New Stat" src="https://github.com/user-attachments/assets/58893e2a-6f36-4a67-92b1-431cbf72e86e" />


Also add an accessor:

<img width="649" height="145" alt="Accessor" src="https://github.com/user-attachments/assets/a46ecf3d-7c82-4a1f-8c45-7e045870e4c4" />


Go to ClassStatConsts.cs and add a new constant for any stat types you created putting it in the appropriate subclass where applicable:

<img width="528" height="288" alt="ClassStatConsts" src="https://github.com/user-attachments/assets/fac99a6a-969d-4853-a93d-85f2522bc9f9" />


Back in the CharacterClassSO.cs (or children), you have to add three more things:

1. In the PopulateData() method add the following to populate newStat with data from the CSVReader dictionary:

<img width="470" height="108" alt="New Stat Instruct" src="https://github.com/user-attachments/assets/184b7985-fcc3-43c7-a184-da0d44610100" />


2. In the ModifyData() method add this:

<img width="557" height="108" alt="New Mod Instruct" src="https://github.com/user-attachments/assets/dfaa4837-9a7b-4c40-b28c-ee24150cd90b" />


3. And finally add the following to the ResetModifiers() method:
<img width="270" height="28" alt="Default" src="https://github.com/user-attachments/assets/dcceeb74-f59b-47cf-8c48-f813b8792ab7" />

