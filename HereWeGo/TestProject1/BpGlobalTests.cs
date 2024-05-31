using Example;

namespace TestProject1;

public class BpGlobalTests
{
    [Fact]
    public void TestPositive()
    {
        var lines = new[]
        {
            "a->b",
            "r->s",
            "b->c",
            "x->c",
            "q->r",
            "y->x",
            "w->z",
            "a, c, r",
            "a, q, w",
            "y, z, a, r",
            "a, w"
        };
        
        var expectedResults = new[]
        {
            "True",
            "False",
            "True",
            "False"
        };

        BpGlobal2 global = new BpGlobal2();
        var result = global.MainProblem(lines);
        Assert.Equal( expectedResults,result);
        
    }
    
    [Fact]
    public void TestPositive2()
    {
        var lines = new[]
        {
            "A->B",
            "G->B",
            "B->C",
            "C->D",
            "D->E",
            "H->J",
            "J->F",
            "A, G, E",
            "H, A"
        };

        var expectedResults = new[]
        {
            "True",
            "False"
        };

        BpGlobal2 global = new BpGlobal2();
        var result = global.MainProblem(lines);
        Assert.Equal( result,expectedResults);
        
    }
    
    [Fact]
    public void TestPositive3()
    {
        var lines = new[]
        {
            "ABC->BCD",
            "BCD->CDE",
            "DEF->EFG",
            "EFG->BCD",
            "123->456",
            "ABC, CDE",
            "123, DEF",
            "ABC, DEF"
        };

        var expectedResults = new[]
        {
            "True",
            "False",
            "True"
        };

        BpGlobal2 global = new BpGlobal2();
        var result = global.MainProblem(lines);
        Assert.Equal( result,expectedResults);
        
    }
    
    [Fact]
    public void TestPositive4()
    {
        var lines = new[]
        {
            "X->Y",
            "Y->X",
            "A->B",
            "B->C",
            "X, A"
        };

        var expectedResults = new[]
        {
            "Error Thrown!"
        };

        BpGlobal2 global = new BpGlobal2();
        var result = global.MainProblem(lines);
        Assert.Equal( result,expectedResults);
        
    }
}