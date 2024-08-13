using System.Text;

namespace HereWeGo;

public class Stack1
{
    public string DecodeString(string s) {
        //we have to eliminate all numbers
        //get first number then get substring where start indexx is index of number+2 
        // and end index is next ] in string. Add that string in stack in multiple of numbers
        Stack<string> stackData=new Stack<string>();

        stackData.Push(s);
        return DecodeMe(stackData);
    }
    
    
    private string DecodeMe(Stack<string> decodeItStack)
    {
        string decodeIt=decodeItStack.Peek();

        decodeItStack.Pop();
        int firstNum=0;
        int openingOccurences=0;
        int closingOccurences=0;
        StringBuilder stringToAddinStack = new StringBuilder();


        for(int i=0; i < decodeIt.Length; i++)
        {
            switch (openingOccurences)
            {
                case 0 when closingOccurences ==0 && Char.IsLetter(decodeIt[i]):
                    decodeItStack.Push(decodeIt[i].ToString()) ;
                    continue;
                case 0 when closingOccurences ==0 && Char.IsDigit(decodeIt[i]):
                    firstNum=(firstNum *10 ) + decodeIt[i] - '0' ;
                    continue;
            }

            if(decodeIt[i] =='[')
            {

                openingOccurences++;
            }

            if(decodeIt[i] ==']')
            {

                closingOccurences++;
            }
            stringToAddinStack.Append(decodeIt[i].ToString())  ;

            if(openingOccurences> 0 && openingOccurences == closingOccurences)
            {
                string addMe=stringToAddinStack.ToString().Substring(1,         stringToAddinStack.Length -1-1);
                //Add value in stack
                for(int j=0; j <firstNum; j++ )
                {
                    decodeItStack.Push(addMe);
                }
                //Replace input string

                openingOccurences=0;
                closingOccurences=0;
                stringToAddinStack=new StringBuilder();
                firstNum = 0;

            }

            if(i == decodeIt.Length-1 && openingOccurences == 0 &&  closingOccurences ==0  && stringToAddinStack.Length > 0)
            {
                decodeItStack.Push(stringToAddinStack.ToString());
            }

            
        }

        string outPut=String.Empty;
        while(decodeItStack.Any())
        {
            string stackTop=decodeItStack.Peek();
            if(stackTop.Contains('['))
            {
                outPut=DecodeMe(decodeItStack) +outPut ;
            }
            else
            {
                outPut=stackTop +outPut ;
                decodeItStack.Pop();
            }
        }

        return outPut;
        

    }
}