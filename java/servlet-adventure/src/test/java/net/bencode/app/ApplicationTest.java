package net.bencode.app;

import org.junit.Test;

import java.util.ArrayList;
import java.util.Arrays;

import static org.junit.Assert.*;

public class ApplicationTest {

    @Test
    public void simpleTest() {
        Application application = new Application();
        int result = application.sumNumbers(Arrays.asList(1, 2, 3));
        assertEquals("Sum is 6", 6, result);
    }

}
