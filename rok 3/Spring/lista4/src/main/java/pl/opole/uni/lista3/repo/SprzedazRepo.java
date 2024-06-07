package pl.opole.uni.lista3.repo;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;
import pl.opole.uni.lista3.model.Sprzedaz;

@Repository
public interface SprzedazRepo extends JpaRepository<Sprzedaz,Integer> {

}
