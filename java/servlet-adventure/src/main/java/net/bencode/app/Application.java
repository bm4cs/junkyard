package net.bencode.app;

import java.util.Collection;
import java.util.Optional;

public class Application {

    public static void main(String[] args) {
        System.out.println("hello linux");
    }

    public int sumNumbers(Collection<Integer> numbers) {
        Optional<Integer> reduced = numbers
                .stream()
                .sorted()
                .reduce((n1, n2) -> n1 + n2);

        return reduced.get();
    }
}
