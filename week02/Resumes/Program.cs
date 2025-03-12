using System;

class Program
{
    static void Main(string[] args)
    {
        // Create job 1
        Job job1 = new Job();
        job1._company = "Microsoft";
        job1._jobTitle = "Software Engineer";
        job1._startYear = 2015;
        job1._endYear = 2018;

        // create job 2
        Job job2 = new Job();
        job2._company = "Apple";
        job2._jobTitle = "Manager";
        job2._startYear = 2019;
        job2._endYear = 2020;

        // Display jobs
        //job1.Display();
        //job2.Display();

        // Create a new resume
        Resume myResume = new Resume();

        // Add name to the resume
        myResume._name = "Allison Rose";

        // Add job1 &2 to the resume
        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        // Display the final result
        myResume.Display();
    }
}