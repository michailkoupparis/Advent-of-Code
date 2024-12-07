import java.io.File;

import historianHysteria.HistorianHysteria;
import historianHysteria.HistorianHysteriaInput;

public class SartUp {

	public static void main(String[] args) {
		int resultExmaple = HistorianHysteria.calculateSimilarity(HistorianHysteriaInput.EXAMPLE_INPUT.getList1(), HistorianHysteriaInput.EXAMPLE_INPUT.getList2());
		System.out.println(resultExmaple);
		var input = new HistorianHysteriaInput("Inputs/day1_input.txt");
		int result = HistorianHysteria.calculateSimilarity(input.getList1(), input.getList2());
		System.out.println(result);
	}

}
