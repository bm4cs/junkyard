package net.bencode.ejb;

import static java.lang.annotation.ElementType.METHOD;
import static java.lang.annotation.ElementType.CONSTRUCTOR;
import static java.lang.annotation.ElementType.TYPE;
import static java.lang.annotation.RetentionPolicy.RUNTIME;

import java.lang.annotation.Inherited;
import java.lang.annotation.Retention;
import java.lang.annotation.Target;
import javax.interceptor.InterceptorBinding;

/**
 * @author Arun Gupta
 */
@Inherited
@InterceptorBinding
@Retention(RUNTIME)
@Target({CONSTRUCTOR, METHOD, TYPE})
public @interface MyAroundConstructInterceptorBinding {
}
