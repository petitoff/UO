package pl.opole.uni.lista3.repo;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import pl.opole.uni.lista3.model.Autor;
import pl.opole.uni.lista3.model.RodzajKsiazki;

@Repository
public interface RodzajKsiazkiRepo  extends JpaRepository<RodzajKsiazki,Integer> {
}
