package pl.uni.opole.lista5.service;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.userdetails.UserDetails;
import org.springframework.security.core.userdetails.UserDetailsService;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.stereotype.Service;
import pl.uni.opole.lista5.model.User;
import pl.uni.opole.lista5.repo.UserRepo;

@Service
public class UserService implements UserDetailsService {
    @Autowired
    private UserRepo repo;


    @Override
    public UserDetails loadUserByUsername(String username) throws UsernameNotFoundException {
        return repo.findByUsername(username);
    }

    public void saveUser (User user)
    {
        repo.save(user);
    }
}
