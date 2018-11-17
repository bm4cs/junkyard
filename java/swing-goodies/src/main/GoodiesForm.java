package main;

import com.jgoodies.forms.builder.PanelBuilder;
import com.jgoodies.forms.factories.ButtonBarFactory;
import com.jgoodies.forms.layout.CellConstraints;
import com.jgoodies.forms.layout.FormLayout;
import com.jgoodies.looks.plastic.Plastic3DLookAndFeel;

import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class GoodiesForm extends JFrame implements ActionListener {

    private JMenu fooMenu;

    public GoodiesForm() {
        super();
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.setTitle("JGoodies FormLayout layout manager demo");
        this.setIconImage(new ImageIcon(this.getClass().getResource("/sport_8ball.png")).getImage());
        this.buildMenu();
        initialise(this);
    }

    private void buildMenu() {
        fooMenu = new JMenu("File");
        fooMenu.setMnemonic('F');

        JMenuItem aboutItem = new JMenuItem("About...");
        aboutItem.setMnemonic('A');
        aboutItem.setEnabled(true);
        aboutItem.setIcon(new ImageIcon(this.getClass().getResource("/comment.png")));
        aboutItem.addActionListener(new ActionListener() {
            public void actionPerformed(ActionEvent e) {
            JLabel imageLabel = new JLabel(new ImageIcon(this.getClass().getResource("/solve_all_problems.gif")));
            JOptionPane.showMessageDialog(null, imageLabel, "About", JOptionPane.PLAIN_MESSAGE);
            }
        });

        JMenuItem exitItem = new JMenuItem("Exit");
        exitItem.setMnemonic('x');
        exitItem.setEnabled(true);
        exitItem.setIcon(new ImageIcon(this.getClass().getResource("/delete.png")));
        exitItem.addActionListener(this);

        fooMenu.add(aboutItem);
        fooMenu.addSeparator();
        fooMenu.add(exitItem);

        JMenuBar menuBar = new JMenuBar();
        menuBar.add(fooMenu);
        setJMenuBar(menuBar);
    }

    private void initialise(GoodiesForm goodiesForm) {
        System.out.println("GoodiesBlit running...");

        // 1. Create the layout
        FormLayout layout = new FormLayout(
                "right:pref, 3dlu, pref:grow, 7dlu, right:pref, 3dlu, pref:grow", // 7 columns
                "p, 3dlu, p, 3dlu, p, 9dlu, p, 3dlu, p, 3dlu, p, 9dlu, p");      // 13 rows

        // 2. Specify column and row groups
        layout.setColumnGroups(new int[][] {{1, 5}, {3, 7}});

        // 3. Create and configure builder
        PanelBuilder builder = new PanelBuilder(layout);
        builder.setDefaultDialogBorder();

        // 4. Add components
        CellConstraints cc = new CellConstraints();
        builder.addSeparator("General", cc.xyw(1,  1, 7));
        builder.addLabel("Company", cc.xy(1, 3));
        builder.add(new JTextField(), cc.xyw(3, 3, 5));
        builder.addLabel("Contact", cc.xy(1, 5));
        builder.add(new JTextField(), cc.xyw(3, 5, 5));
        builder.addSeparator("Propeller", cc.xyw(1, 7, 7));
        builder.addLabel("PTI [kW]", cc.xy(1, 9));
        builder.add(new JTextField(), cc.xy(3, 9));
        builder.addLabel("Power [kW]", cc.xy(5, 9));
        builder.add(new JTextField(), cc.xy(7, 9));
        builder.addLabel("R [mm]", cc.xy(1, 11));
        builder.add(new JTextField(), cc.xy(3, 11));
        builder.addLabel("D [mm]", cc.xy(5, 11));
        builder.add(new JTextField(), cc.xy(7, 11));
        builder.add(ButtonBarFactory.buildCenteredBar(new JButton("Ignite"), new JButton("Explode")), cc.xyw(1, 13, builder.getColumnCount()));


        JPanel goodiesPanel = builder.getPanel();
        goodiesPanel.setPreferredSize(new Dimension(400, 250));
        goodiesForm.getContentPane().add(goodiesPanel);
    }

    public static void main(String[] args) {
        try {
            UIManager.setLookAndFeel(new Plastic3DLookAndFeel());
        }
        catch (Exception exception) {
            exception.printStackTrace();
        }

        GoodiesForm form = new GoodiesForm();
        form.pack();
        form.setVisible(true);
    }

    @Override
    public void actionPerformed(ActionEvent e) {
        System.out.println(e.toString());
    }
}