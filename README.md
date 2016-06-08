# Projects
Simple implementation of a toy robot problem.

There are 3 projects:
1. ToyRobots - only main method is here it delegates entire logic to Robots lib. Unfortunately in .NET world you need to have a special type of project that builds .exe file. Such project is bad for everything, that's why as soon as possible to just call lib (in my case Robots solution) to do everything.
2. Robots - everything to make things happen
3. RobotsTests - tests for Robots lib

# Approach
I like to think that each programming language and frameworks have a specific culture build around it. The philosophy of a platform. That's why various problems are solved differently in different programming languages. C# community just like Java community is strongly bound to object oriented approach. That's why I was trying to solve various challenges following the way that would be commonly used by a dev community associated with C# language. It means that various challenges were tackled by using more object oriented patterns then by a simple procedural approach that is more typical for Python, Ruby, Node community.

A good example of such decision is a CardinalEngine class. I absolutely hate to see switch statements for a list longer than 3 elements in C# language. I noticed that there are multiple operations that are related with the orientation of a robot and I implemented them by creating a specialized type for each cardinal direction. My solution in different programming language would be different, but definitely in C# this is how I would do it. The big plus of such solution is being able to easily add additional direction oriented operations or even add additional directions. The downside is creation of multiple classes that have certain boilerplate in c# language.

Next example of doing something in more C# way was the extraction of internal RobotService class from InputManager. InputManager is pretty heavy - it has multiple responsibilities, extracting robot helping operations allowed me to make InputManager easier to read and maintain. I would also highlight the way how dealing with robot operations was handled in RobotService - a dictionary with expression tree (_validOperations). Due to such approach it is easy to add more robot operations - you just do them in one place and everything plugs in automatically. The downside of such approach is again additional boilerplate and complexity of a data structure. Also it means that I ended up having certain abstractions that again is not typical for Python, Node.

As a final result I ended up having a really simple code that is easy to extend, but overall it is split into multiple files and it has certain abstractions.

I didn't spend too much time validating the input. I guessed that it is not a main goal of this exercise. It is easy to add it in CoordinatesValidator and InputManager if it is needed. Other than that application should run according to specification.

# Tests
I really like to follow way of writing tests suggested by Roy Osherove - method naming conventions, test implementation according to assign act assert (3A). Not testing internal classes, and focusing on logic and not data that is kept by a class. I didn't spend time trying to test the main method - again usually you don't do it and it is not a goal of this exercise.

# Where to start looking at code
I suggest starting from Robots.InputManager.Start(path). Start method is called from exe file and takes as a parameter a file to parse.