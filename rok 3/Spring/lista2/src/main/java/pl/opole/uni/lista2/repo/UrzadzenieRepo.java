package pl.opole.uni.lista2.repo;

import jakarta.persistence.criteria.CriteriaBuilder;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import pl.opole.uni.lista2.model.RodzajUrzadzenia;
import pl.opole.uni.lista2.model.Urzadzenie;

import java.util.List;

@Repository
public interface UrzadzenieRepo extends JpaRepository<Urzadzenie, Integer> {
    List<Urzadzenie> findByRodzajUrzadzeniaRodzajUrzadzeniaIDEquals (Integer id);
    List<Urzadzenie> findByProducentProducentIDNot (Integer id);
}
