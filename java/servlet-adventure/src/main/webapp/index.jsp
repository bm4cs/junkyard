<%@ page import="org.joda.time.DateTimeZone" %>
<%@ page import="org.joda.time.DateTime" %>
<!doctype html>
<html class="no-js" lang="en">
<head>
    <meta charset="utf-8"/>
    <meta name="viewport" content="width=device-width, initial-scale=1.0"/>
    <title>Ben's Silly JSP</title>
    <link rel="stylesheet" href="css/foundation.min.css">
</head>
<body>

<div class="top-bar">
    <div class="top-bar-left">
        <ul class="menu">
            <li class="menu-text">Blog</li>
            <li><a href="#">One</a></li>
            <li><a href="#">Two</a></li>
            <li><a href="#">Three</a></li>
        </ul>
    </div>
</div>

<div class="callout large primary">
    <div class="row column text-center">
        <h1>JVM Performance Hood</h1>
    </div>
</div>

<div class="row medium-8 large-7 columns">
    <div class="blog-post">
        <h3>JodaTime demos <small>It's tiny!</small></h3>

        <blockquote>
            <%= new DateTime()%>
            <cite>new DateTime()</cite>
        </blockquote>

        <blockquote>
            <%= new DateTime().toInstant()%>
            <cite>new DateTime().toInstant()</cite>
        </blockquote>

        <blockquote>
            <%= new DateTime(DateTimeZone.UTC)%>
            <cite>new DateTime(DateTimeZone.UTC)</cite>
        </blockquote>

        <div class="callout">
            <ul class="menu simple">
                <li><a href="#">Author: @vimjock</a></li>
                <li><a href="#">Comments: 3</a></li>
            </ul>
        </div>
    </div>

    <div class="blog-post">
        <h3>Awesome blog post title <small>3/6/2015</small></h3>
        <img class="thumbnail" src="http://placehold.it/850x350">
        <p>Praesent id metus massa, ut blandit odio. Proin quis tortor orci. Etiam at risus et justo dignissim congue. Donec congue lacinia dui, a porttitor lectus condimentum laoreet. Nunc eu ullamcorper orci. Quisque eget odio ac lectus vestibulum faucibus eget in metus. In pellentesque faucibus vestibulum. Nulla at nulla justo, eget luctus.</p>
        <div class="callout">
            <ul class="menu simple">
                <li><a href="#">Author: Mike Mikers</a></li>
                <li><a href="#">Comments: 3</a></li>
            </ul>
        </div>
    </div>


    <div class="blog-post">
        <form action="fruit/summer/watermelon" method="post">
            <div class="row">
                <div class="medium-6 columns">
                    <label>First name
                        <input type="text" placeholder="First name" name="firstname">
                    </label>
                </div>
                <div class="medium-6 columns">
                    <label>Last name
                        <input type="text" placeholder="Last name" name="lastname">
                    </label>
                </div>
            </div>
            <label>
                How many puppies?
                <input type="number" value="100" name="puppies">
            </label>
            <input type="submit" class="button" value="Submit">
        </form>
    </div>
</div>
<script src="js/vendor/jquery.min.js"></script>
<script src="js/foundation.js"></script>
<script>
    $(document).foundation();
</script>
</body>
</html>
