package pl.opole.uni.lista2.repo;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.data.jpa.repository.Query;
import org.springframework.stereotype.Repository;
import pl.opole.uni.lista2.model.Producent;

import java.util.List;

@Repository
public interface ProducentRepo extends JpaRepository<Producent,Integer> {

    @Query(value = "SELECT p FROM Producent p WHERE p.nazwa LIKE '%men%'")
    List<Producent> findContainmenJPQL();

    @Query(value = "SELECT * FROM producent WHERE nazwa LIKE '%men%'",nativeQuery = true)
    List<Producent> findContainmenSQL();

    @Query(value = "SELECT p FROM Producent p WHERE p.nazwa NOT LIKE '%on%'")
    List<Producent> findContainNotonJPQL();

    @Query(value = "SELECT * FROM producent WHERE nazwa NOT LIKE '%on%'",nativeQuery = true)
    List<Producent> findContainNotonSQL();
}
