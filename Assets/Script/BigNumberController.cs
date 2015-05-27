using UnityEngine;
using System.Collections;

public class BigNumberController : MonoBehaviour {

	BigNumberHandler bigNumber = new BigNumberHandler();

	decimal roundedNumber;

	public string ExportNumber(decimal nNumber){
		string sNumber;
		bigNumber.num = 0;
		bigNumber.suffixIdx = 0;

		bigNumber.num = nNumber;
		bigNumber.MakeSuffix();

		if (nNumber < 1000){
			bigNumber.num = ShowDecimalRound(bigNumber.num,0);
		}else{
			bigNumber.num = ShowDecimalRound(bigNumber.num,2);
		}

		return sNumber = bigNumber.num + bigNumber.suffix[bigNumber.suffixIdx];
	}

	public static decimal ShowDecimalRound( decimal Argument, int Digits ){
		decimal roundedNumber = decimal.Round( Argument, Digits );
		return roundedNumber;
	}
}

