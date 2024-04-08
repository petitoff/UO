package pl.opole.uni.lista2.repo;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import pl.opole.uni.lista2.model.RodzajUrzadzenia;

import java.util.List;

@Repository
public interface RodzajUrzadzeniaRepo extends JpaRepository<RodzajUrzadzenia,Integer> {
    List<RodzajUrzadzenia> findByNazwaStartingWith (String nazwa);

}
