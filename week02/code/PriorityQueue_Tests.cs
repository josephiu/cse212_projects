using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario:  This test the Piority of the queue. The test will call the prioriyQueue class
    // which accepts two parametere ,  the value whcih is a string and the priority which is an intiger, 
    // Expected Result:  i am expecting the priorityQueue Dequeue  best on priority in this case base on the larg number nuber
    // Defect(s) Found: there was a flaw in the foreach stetatment that is finding the priority and when i removed it it worked
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 1);
        priorityQueue.Enqueue("Medium", 5);
        priorityQueue.Enqueue("High", 10);



        // Assert.Fail("Implement the test case and then remove this.");s
        Assert.AreEqual("High", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: This test checks for empty queue
    // Expected Result:  iam expecting to have an ivalide operation exception when the cod runs
    // Defect(s) Found: becuase i fixed the defects in the first test then this code runs very well no defect.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
       
        
         Assert.ThrowsException<InvalidOperationException>(() => priorityQueue.Dequeue());
}

    // Add more test cases as needed below.
}