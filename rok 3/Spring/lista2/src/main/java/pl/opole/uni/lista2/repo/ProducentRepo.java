package pl.opole.uni.lista2.repo;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import pl.opole.uni.lista2.model.Producent;

import java.util.List;

@Repository
public interface ProducentRepo extends JpaRepository<Producent,Integer> {
    List<Producent> findByNazwaContaining (String nazwa);
    List<Producent> findByNazwaNotContaining (String nazwa);
}
