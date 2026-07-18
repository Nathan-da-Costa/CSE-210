/*
WHAT IS ABSTRACTION AND WHY IS IT IMPORTANT?

To me, abstraction is basically about separating what an object does from how it actually does it. 
Instead of forcing the main part of the program to handle every single low-level detail and mechanic, 
we create classes that hide that complexity. Anyone using the class only needs to know about the 
simple public methods, without worrying about the heavy logic running behind the scenes.

The main benefit of this is how much easier it makes code maintenance and organization. Because 
the complex details are isolated inside each specific class, you can change how a feature works 
internally without breaking the rest of the application. It makes the code much cleaner, easier to 
read, and stops a single change from causing a domino effect of bugs across your project.

In our journal program, we used abstraction by splitting up the responsibilities. The main file 
(Program.cs) just manages the menu loop and triggers actions, but it has no idea how the data is 
actually handled under the hood. 

A clear example of this from our code is when the user chooses to save their file:

Console.Write("What is the filename? ");
string savePath = Console.ReadLine();
executionJournal.SaveToFile(savePath);

As you can see, Program.cs simply gets the filename from the user and runs SaveToFile(savePath). 
The main program doesn't know—and doesn't need to know—how the journal saves the text, that we 
are using the ~ character as a delimiter, or how the file system writes it to the disk. All of 
that file handling logic is hidden away inside the Journal class. If I decide tomorrow to change 
the save format to JSON or a database, I only have to update the inside of the Journal class, 
and this specific block of code above will keep working perfectly without touching a single line.
*/