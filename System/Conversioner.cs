using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Conversioner
{        
    public static int BinaryToDecimal(int indexBinary){
        string decimalString = indexBinary.ToString();
   
        int decimalValue = 0;
        

        for(int i = 0; i < decimalString.Length; i++){
            decimalValue += int.Parse(decimalString[decimalString.Length - 1 - i].ToString()) * (int)Mathf.Pow(2,i);
        }

        return decimalValue;
    }

    public static int DecimalToBinary(int indexDecimal){

        string tempBinaryString = "";
        string binaryValue = "";

        for(int i = 0; indexDecimal > 0; i++){
            tempBinaryString += (indexDecimal % 2).ToString();
            indexDecimal /= 2;
        }
        
        for(int i = 0; i < tempBinaryString.Length; i++){
            binaryValue += tempBinaryString[tempBinaryString.Length - 1 - i];
        }

        return int.Parse(binaryValue);
    }
}
