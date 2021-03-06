package net.bencode.ejb;

import java.util.ArrayList;
import java.util.List;
import javax.annotation.PostConstruct;
import javax.annotation.PreDestroy;
import javax.ejb.PostActivate;
import javax.ejb.PrePassivate;
import javax.ejb.Stateful;
import javax.enterprise.context.Dependent;

/**
 * @author Arun Gupta
 */
@Dependent
//@MyAroundConstructInterceptorBinding
@Stateful
public class MyStatefulBean implements MyStatefulBeanLocal {
    private List<String> list;

    public MyStatefulBean() {
        System.out.println("MyStatefulBean.ctor");
    }

    @PostConstruct
    private void postConstruct() {
        list = new ArrayList<>();
        System.out.println("MyStatefulBean.postConstruct");
    }

    @PreDestroy
    private void preDestroy() {
        System.out.println("MyStatefulBean.preDestroy");
    }

    @PrePassivate
    private void prePassivate() {
        System.out.println("MyStatefulBean.prePassivate");
    }

    @PostActivate
    private void postActivate() {
        System.out.println("MyStatefulBean.postActivate");
    }

    @Override
    public void addItem(String item) {
        list.add(item);
        System.out.println("MyBean.addItem");
    }

    @Override
    public void removeItem(String item) {
        list.remove(item);
        System.out.println("MyBean.removeItem");
    }

    @Override
    public List<String> items() {
        return list;
    }
}
