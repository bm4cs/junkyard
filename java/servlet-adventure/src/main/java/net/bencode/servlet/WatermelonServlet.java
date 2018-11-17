package net.bencode.servlet;

import java.io.IOException;
import java.io.PrintWriter;
import javax.servlet.ServletConfig;
import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

public class WatermelonServlet extends HttpServlet {
    private static final long serialVersionUID = 1L;

    public WatermelonServlet() {
        super();
    }

    @Override
    public void init(ServletConfig config) throws ServletException {
        super.init(config);

        String driver = getInitParameter("driver");
        String url = getInitParameter("url");
        System.out.printf("driver: %s\n", driver);
        System.out.printf("url: %s\n", url);
    }


    protected void doGet(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {

        response.setContentType("text/plain");
        PrintWriter out = response.getWriter();
        out.append("watermelon is yummy");
    }

    protected void doPost(HttpServletRequest request, HttpServletResponse response)
            throws ServletException, IOException {
        PrintWriter out = response.getWriter();

        if (request.getParameter("firstname") != null) {
            out.append(request.getParameter("firstname") + " ");
        }

        doGet(request, response);
    }
}
