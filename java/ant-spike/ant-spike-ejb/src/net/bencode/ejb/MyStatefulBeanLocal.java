package net.bencode.ejb;

import javax.ejb.Local;
import java.util.List;

@Local
public interface MyStatefulBeanLocal {
    void addItem(String item);

    void removeItem(String item);

    List<String> items();
}
