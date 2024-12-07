package Helpers;

import java.io.*;
import java.util.*;

public class HelperFunctions {

    /**
     * Creates a count dictionary (map) for the list of integers
     *
     * @param ints List of integers
     * @return A map with the count of each integer in the list
     */
    public static Map<Integer, Integer> getCountDictionary(List<Integer> ints) {
        Map<Integer, Integer> counter = new HashMap<>();
        for (int i : ints) {
            counter.put(i, counter.getOrDefault(i, 0) + 1);
        }
        return counter;
    }
}
