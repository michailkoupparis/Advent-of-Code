package historianHysteria;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.util.ArrayList;
import java.util.List;

public class HistorianHysteriaInput {

    public static final HistorianHysteriaInput EXAMPLE_INPUT =
            new HistorianHysteriaInput(
                    List.of(3, 4, 2, 1, 3, 3),
                    List.of(4, 3, 5, 3, 9, 3)
            );

    private final List<Integer> list1;
    private final List<Integer> list2;

    private HistorianHysteriaInput(List<Integer> list1, List<Integer> list2) {
        this.list1 = new ArrayList<>(list1);
        this.list2 = new ArrayList<>(list2);
    }

    public HistorianHysteriaInput(String inputTextFile) {
        this.list1 = new ArrayList<>();
        this.list2 = new ArrayList<>();

        List<String> lines;
        try {
            lines = Files.readAllLines(Paths.get(inputTextFile));
        } catch (IOException ex) {
            System.err.println("Error reading file: " + ex.getMessage());
            throw new RuntimeException("Failed to read input file", ex);
        }

        for (String line : lines) {
            String[] lineParts = line.trim().split("\\s+");
            if (lineParts.length >= 2) {
                try {
                    list1.add(Integer.parseInt(lineParts[0]));
                    list2.add(Integer.parseInt(lineParts[1]));
                } catch (NumberFormatException e) {
                    System.err.println("Invalid number format in line: " + line);
                    throw e;
                }
            } else {
                System.err.println("Malformed line: " + line);
                throw new IllegalArgumentException("Input line does not contain two numbers");
            }
        }
    }

    public List<Integer> getList1() {
        return list1;
    }

    public List<Integer> getList2() {
        return list2;
    }
}
