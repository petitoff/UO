package pl.uni.opole.lista5;

import javax.sql.DataSource;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.boot.context.event.ApplicationReadyEvent;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.context.event.EventListener;
import org.springframework.http.HttpMethod;
import org.springframework.security.authentication.AuthenticationManager;
import org.springframework.security.authentication.dao.DaoAuthenticationProvider;
import org.springframework.security.config.annotation.authentication.builders.AuthenticationManagerBuilder;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.configurers.AbstractHttpConfigurer;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.security.provisioning.JdbcUserDetailsManager;
import org.springframework.security.provisioning.UserDetailsManager;
import org.springframework.security.web.SecurityFilterChain;
import org.springframework.web.context.WebApplicationContext;

import jakarta.annotation.PostConstruct;
import pl.uni.opole.lista5.model.User;
import pl.uni.opole.lista5.service.UserService;
import pl.uni.opole.lista5.RestAuthenticationEntryPoint;

@Configuration
public class SecurityConfig {

	@Autowired
    private DataSource dataSource;
	
	@Autowired
    private WebApplicationContext applicationContext;
	
	@Autowired 
	private RestAuthenticationEntryPoint authenticationEntryPoint;
	
	private UserService userDetailsService;
	
	@PostConstruct
    public void completeSetup() {
        userDetailsService = applicationContext.getBean(UserService.class);
    }
	
	@Bean
    public SecurityFilterChain filterChain(HttpSecurity http) throws Exception {
        
        http.authorizeHttpRequests(auth -> auth.requestMatchers("/selectRodzajKsiazki").hasRole("ADMIN")
                .requestMatchers("/insertRodzajKsiazki").hasRole("ADMIN")
                .requestMatchers("/updateRodzajKsiazki").hasRole("ADMIN")
                .requestMatchers("/deleteRodzajKsiazki").hasRole("ADMIN")
                .requestMatchers("/insertAutor").hasAnyRole("ADMIN", "MODERATOR")
                .requestMatchers("/updateAutor").hasAnyRole("ADMIN", "MODERATOR")
                .requestMatchers("/deleteAutor").hasAnyRole("ADMIN", "MODERATOR")
                .requestMatchers("/insertksiazki").hasAnyRole("ADMIN", "MODERATOR")
                .requestMatchers("/updateksiazki").hasAnyRole("ADMIN", "MODERATOR")
                .requestMatchers("/deleteksiazki").hasAnyRole("ADMIN", "MODERATOR")
                .requestMatchers("/selectAutor").authenticated()
                .requestMatchers("/selectksiazki").permitAll()
                .requestMatchers("/selectSprzedaz").authenticated()
                .requestMatchers("/insertSprzedaz").authenticated()
                .requestMatchers("/updateSprzedaz").hasRole("ADMIN")
                .requestMatchers("/deleteSprzedaz").hasRole("ADMIN")
        //.formLogin(form -> form.permitAll()
        ).httpBasic(httpSecurityHttpBasicConfigurer -> httpSecurityHttpBasicConfigurer.authenticationEntryPoint(authenticationEntryPoint))
        .csrf(AbstractHttpConfigurer::disable);
        
        return http.build();
               
    }
	
	@Bean
    public UserDetailsManager users(HttpSecurity http) throws Exception {
        AuthenticationManagerBuilder authenticationManagerBuilder = http.getSharedObject(AuthenticationManagerBuilder.class);
        authenticationManagerBuilder.userDetailsService(userDetailsService).passwordEncoder(passwordEncoder());
        authenticationManagerBuilder.authenticationProvider(authenticationProvider());
        AuthenticationManager authenticationManager = authenticationManagerBuilder.build();

        JdbcUserDetailsManager jdbcUserDetailsManager = new JdbcUserDetailsManager(dataSource);
        jdbcUserDetailsManager.setAuthenticationManager(authenticationManager);
        return jdbcUserDetailsManager;
    }
	
	 @Bean
    public DaoAuthenticationProvider authenticationProvider() {
        final DaoAuthenticationProvider authProvider = new DaoAuthenticationProvider();
        authProvider.setUserDetailsService(userDetailsService);
        authProvider.setPasswordEncoder(passwordEncoder());
        return authProvider;
    }
	
	@Bean
	public PasswordEncoder passwordEncoder()
	{
		return new BCryptPasswordEncoder();
	}
	
//	@EventListener(ApplicationReadyEvent.class)
//	public void establishUsers()
//	{
//		userDetailsService.saveUser(new User("michal", passwordEncoder().encode("michal"), "ROLE_USER"));
//		userDetailsService.saveUser(new User("admin", passwordEncoder().encode("admin"), "ROLE_ADMIN"));
//		userDetailsService.saveUser(new User("dawid", passwordEncoder().encode("dawid"), "ROLE_MODERATOR"));
//		userDetailsService.saveUser(new User("kuba", passwordEncoder().encode("kuba"), "ROLE_USER"));
//	}
//
	
}
