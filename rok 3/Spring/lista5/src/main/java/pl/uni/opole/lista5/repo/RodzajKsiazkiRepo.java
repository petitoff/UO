package pl.uni.opole.lista5.repo;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import pl.uni.opole.lista5.model.Autor;
import pl.uni.opole.lista5.model.RodzajKsiazki;

@Repository
public interface RodzajKsiazkiRepo  extends JpaRepository<RodzajKsiazki,Integer> {
}
