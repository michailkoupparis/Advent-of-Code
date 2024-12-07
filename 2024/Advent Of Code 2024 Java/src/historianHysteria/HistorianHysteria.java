package historianHysteria;

import java.util.*;
import Helpers.HelperFunctions;

public class HistorianHysteria {

    /**
     * For Part 1 of the HistorianHysteria task
     *
     * @param list1 First list of integers
     * @param list2 Second list of integers
     * @return Calculated distance
     */
    public static int calculateDistance(List<Integer> list1, List<Integer> list2) {
        Collections.sort(list1);
        Collections.sort(list2);

        int difference = 0;
        for (int i = 0; i < list1.size(); i++) {
            difference += Math.abs(list1.get(i) - list2.get(i));
        }

        return difference;
    }

    /**
     * For Part 2 of the HistorianHysteria task
     *
     * @param list1 First list of integers
     * @param list2 Second list of integers
     * @return Calculated similarity
     */
    public static int calculateSimilarity(List<Integer> list1, List<Integer> list2) {
        Map<Integer, Integer> countList1 = HelperFunctions.getCountDictionary(list1);
        Map<Integer, Integer> countList2 = HelperFunctions.getCountDictionary(list2);

        int similarity = 0;
        for (Map.Entry<Integer, Integer> entry : countList1.entrySet()) {
            int key = entry.getKey();
            int value = entry.getValue();

            if (countList2.containsKey(key)) {
                similarity += key * value * countList2.get(key);
            }
        }

        return similarity;
    }
}

