package pl.opole.uni.lista2.repo;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import pl.opole.uni.lista2.model.Dzial;

import java.util.List;

@Repository
public interface DzialRepo extends JpaRepository<Dzial,Integer> {
    List<Dzial> findByNazwaEndingWith (String name);
}
