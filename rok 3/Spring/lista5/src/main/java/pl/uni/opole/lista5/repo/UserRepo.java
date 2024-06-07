package pl.uni.opole.lista5.repo;

import org.springframework.data.jpa.repository.JpaRepository;
import pl.uni.opole.lista5.model.User;

public interface UserRepo extends JpaRepository<User, Integer>
{
    User findByUsername(String username);
}
